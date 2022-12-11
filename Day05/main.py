import re

fileContents = open("input.txt", "r").read()

lines = fileContents.split('\n')

stacks = []

##Part 1
currentLineIndex = 0
while lines[currentLineIndex] != '':
    currentline = lines[currentLineIndex]
    currentLineIndex += 1
    if "]" not in currentline:
        continue
    columns = re.findall("....?", currentline)

    for index, col in enumerate(columns):
        if len(stacks) < index + 1:
            stacks.append([])
        if len(col.strip()) > 0:
            stacks[index].insert(0, col.strip())

currentLineIndex += 1

while currentLineIndex < len(lines):
    currentLine = lines[currentLineIndex]
    tokens = currentLine.split(" ")

    countToMove = int(tokens[1])
    fromColumn = int(tokens[3]) - 1
    toColumn = int(tokens[5]) - 1

    for i in range(countToMove):
        value = stacks[fromColumn].pop()
        stacks[toColumn].append(value)

    currentLineIndex += 1

for index, stack in enumerate(stacks):
    print(index + 1, ":", stack)

print("#######################################")


## Part 2
stacks.clear()

currentLineIndex = 0
while lines[currentLineIndex] != '':
    currentline = lines[currentLineIndex]
    currentLineIndex += 1
    if "]" not in currentline:
        continue
    columns = re.findall("....?", currentline)

    for index, col in enumerate(columns):
        if len(stacks) < index + 1:
            stacks.append([])
        if len(col.strip()) > 0:
            stacks[index].insert(0, col.strip())

currentLineIndex += 1

while currentLineIndex < len(lines):
    currentLine = lines[currentLineIndex]
    tokens = currentLine.split(" ")

    countToMove = int(tokens[1])
    fromColumn = int(tokens[3]) - 1
    toColumn = int(tokens[5]) - 1

    lengthOfFromColumn = len(stacks[fromColumn])
    startIndex = lengthOfFromColumn - countToMove
    itemsToMove = stacks[fromColumn][startIndex:lengthOfFromColumn]
    stacks[toColumn].extend(itemsToMove)
    del stacks[fromColumn][lengthOfFromColumn - countToMove:]

    currentLineIndex += 1

for index, stack in enumerate(stacks):
    print(index + 1, ":", stack)
