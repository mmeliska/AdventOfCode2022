package main

import (
	"fmt"
	"os"
	"strings"
)

func main() {
	fileContent, err := os.ReadFile("../../src/input1.txt")
	check(err)

	fileString := string(fileContent)
	lines := strings.Split(fileString, "\n")

	charMap := make(map[int32]int)
	total := int32(0)

	for index, value := range lines {
		usedChars := make(map[int32]bool)
		for _, c := range value {
			if _, ok := charMap[c]; ok {
				if _, used := usedChars[c]; !used {
					charMap[c]++
					usedChars[c] = true
				}
			} else {
				charMap[c] = 1
				usedChars[c] = true
			}

			if charMap[c] == 3 {
				if c <= 90 {
					priority := c - int32(38)
					total += priority
					fmt.Println(string(c), priority)
				} else {
					priority := c - int32(96)
					total += priority
					fmt.Println(string(c), priority)
				}
				break
			}
		}
		if index%3 == 2 {
			charMap = make(map[int32]int)
		}
	}

	fmt.Println(total)
}

func check(e error) {
	if e != nil {
		panic(e)
	}
}
