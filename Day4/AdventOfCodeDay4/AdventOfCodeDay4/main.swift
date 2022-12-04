//
//  main.swift
//  AdventOfCodeDay4
//
//  Created by Michael Meliska on 12/4/22.
//

import Foundation

// Determine the file name
let filename = "input.txt"

// Read the contents of the specified file
let contents = try! String(contentsOfFile: filename)

// Split the file into separate lines
let lines = contents.split(separator:"\n")


//Part 1
var count = 0

for line in lines {
    let ranges = line.split(separator: ",")
    
    let range1 = ranges[0].split(separator: "-")
    let range2 = ranges[1].split(separator: "-")
    
    let range1Start = Int(range1[0])
    let range1End = Int(range1[1])
    
    let range2Start = Int(range2[0])
    let range2End = Int(range2[1])
    
    if(range1Start! >= range2Start! && range1End! <= range2End! || range2Start! >= range1Start! && range2End! <= range1End!)
    {
        count+=1
    }
}

print(count)


//Part 2
var count2 = 0

for line in lines {
    let ranges = line.split(separator: ",")
    
    let range1 = ranges[0].split(separator: "-")
    let range2 = ranges[1].split(separator: "-")
    
    let range1Start = Int(range1[0])
    let range1End = Int(range1[1])
    
    let range2Start = Int(range2[0])
    let range2End = Int(range2[1])
    
    if(range1Start! >= range2Start! && range1Start! <= range2End! ||
       range1End! >= range2Start! && range1End! <= range2End! ||
       range2Start! >= range1Start! && range2Start! <= range1End! ||
       range2End! >= range1Start! && range2End! <= range1End!)
    {
        count2+=1
    }
}

print(count2)

