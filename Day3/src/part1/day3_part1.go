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

	total := int32(0)

	for _, value := range lines {
		lineLength := len(value)
		bucketSize := lineLength / 2
		bucket1 := value[0:bucketSize]
		bucket2 := value[bucketSize:lineLength]

		charMap := make(map[int32]int)

		for _, c := range bucket1 {
			charMap[c] = 1
		}

		for _, c := range bucket2 {
			if charMap[c] < 2 {
				if _, ok := charMap[c]; ok {

					charMap[c] += 1
					if c <= 90 {
						priority := c - int32(38)
						total += priority
					} else {
						priority := c - int32(96)
						total += priority
					}
				}
			}
		}
	}

	fmt.Println(total)
}

func check(e error) {
	if e != nil {
		panic(e)
	}
}
