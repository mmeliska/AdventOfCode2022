import { File } from './File';
import { Dir } from 'fs';

export class Directory {
  name: string;
  parentDirectory: Directory | null;
  childDirectories: Directory[];
  files: File[];
  size: number;

  constructor(name: string, parentDirectory?: Directory) {
    this.name = name;
    this.parentDirectory = parentDirectory || null;
    this.childDirectories = [];
    this.files = [];
    this.size = 0;
  }

  createDirectory(name: string) {
    let newDirectory = new Directory(name, this);
    this.childDirectories.push(newDirectory);
  }

  createFile(file: File) {
    this.files.push(file);
    this.calculateSize();
  }

  getChildDirectory(name: string) {
    return this.childDirectories.find(x => x.name == name);
  }

  calculateSize() {
    let size = 0;
    size += this.files.map(f => f.size).reduce((partialSum, a) => partialSum + a, 0);
    size += this.childDirectories.map(d => d.size).reduce((partialSum, a) => partialSum + a, 0);
    this.size = size;
    this.parentDirectory?.calculateSize();
  }

  toString(indentLevel: number) {
    let padding = ''.padStart(indentLevel, ' ');
    let filePadding = ''.padStart(indentLevel + 1, ' ');
    let result = `${padding}- ${this.name} (dir, size=${this.size})\n`;
    this.childDirectories.forEach(x => (result += x.toString(indentLevel + 1)));
    this.files.forEach(x => (result += `${filePadding}- ${x.name} (file, size=${x.size})\n`));

    return result;
  }
}
