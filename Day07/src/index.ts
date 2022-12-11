import * as fs from "fs";
import path from "path";
import { Directory } from "./Directory";
import {FileProcessor} from "./FileProcessor";

let fileProcessor = new FileProcessor(path.join(__dirname, "./input.txt"));

fileProcessor.printDirectoryStructure();

console.log(fileProcessor.getSumOfSmallDirectories(100000));
console.log(fileProcessor.findSmallestDirectorySizeLargerThanSize(70000000, 30000000));
