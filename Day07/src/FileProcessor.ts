import fs from 'fs';
import path from 'path';
import { Directory } from './Directory';
import { File } from './File';

export class FileProcessor {
  private lines: string[];
  private rootDirectory: Directory;
  private currentDirectory: Directory;

  constructor(inputFileName: string) {
    let fileContents = fs.readFileSync(inputFileName, {
      encoding: 'utf8'
    });

    this.lines = fileContents.split('\n');

    this.rootDirectory = new Directory('/');
    this.currentDirectory = this.rootDirectory;

    for (let lineIndex in this.lines) {
      let currentLine = this.lines[lineIndex];

      let lineParts = currentLine.split(' ');

      if (currentLine.startsWith('$ cd')) {
        this.processCDCommand(lineParts[2]);
      } else if (currentLine.startsWith('dir ')) {
        this.processCreateDirectoryCommand(lineParts[1]);
      } else if (currentLine == '$ ls') {
        //nothing needs to happen
      } else if (currentLine.length > 0) {
        this.processCreateFileCommand(lineParts[1], parseInt(lineParts[0]));
      }
    }
  }

  processCDCommand(directoryName: string) {
    if (directoryName == '/') {
      this.currentDirectory = this.rootDirectory;
    } else if (directoryName == '..') {
      this.currentDirectory = this.currentDirectory.parentDirectory || this.rootDirectory;
    } else {
      let childDirectory = this.currentDirectory.getChildDirectory(directoryName);
      if (childDirectory) {
        this.currentDirectory = childDirectory;
      } else {
        throw `Directory ${directoryName} could not be found`;
      }
    }
  }

  private processCreateDirectoryCommand(directoryName: string) {
    this.currentDirectory.createDirectory(directoryName);
  }

  private processCreateFileCommand(name: string, size: number) {
    this.currentDirectory.createFile(new File(name, size));
  }

  printDirectoryStructure() {
    console.log(this.rootDirectory.toString(0));
  }

  getSumOfSmallDirectories(smallDirectorySizeThreshold: number) {
    return this.calculateSumOfSmallDirectories(this.rootDirectory, smallDirectorySizeThreshold);
  }

  private calculateSumOfSmallDirectories(directory: Directory, smallDirectorySizeThreshold: number) {
    let sum = 0;
    if (directory.size <= smallDirectorySizeThreshold) {
      sum += directory.size;
    }
    directory.childDirectories.forEach(x => (sum += this.calculateSumOfSmallDirectories(x, smallDirectorySizeThreshold)));
    return sum;
  }

  findSmallestDirectorySizeLargerThanSize(systemSize: number, neededSpace: number) {
    let freeSpace = systemSize - this.rootDirectory.size;
    let minimumSize = neededSpace - freeSpace;

    return this.processFindSmallestDirectorySizeLargerThanSize(this.rootDirectory, minimumSize, this.rootDirectory.size);
  }

  private processFindSmallestDirectorySizeLargerThanSize(directory: Directory, minimumSize: number, currentSmallest: number) {
    let result = currentSmallest;
    if (directory.size > minimumSize) {
      if (directory.size < result) {
        result = directory.size;
      }
      directory.childDirectories.forEach(x => (result = this.processFindSmallestDirectorySizeLargerThanSize(x, minimumSize, result)));
    }
    return result;
  }
}
