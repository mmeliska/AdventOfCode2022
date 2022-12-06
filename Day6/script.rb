# frozen_string_literal: true
def calcSignalPosition(input, requiredUniqueChars)
  lastChars = ""
  input.each_char.with_index do |c, index|

    indexOfChar = lastChars.index(c)

    if indexOfChar != nil
      lastChars = lastChars[indexOfChar + 1..-1] + c
    elsif lastChars.length < requiredUniqueChars
      lastChars += c
    end

    if lastChars.length == requiredUniqueChars
      return index + 1
    end

  end

  return lastChars.length == 14 ? input.length : -1
end

input = File.read("input.txt")

# Part 1
position1 = calcSignalPosition(input, 4)
puts(position1)

# Part 2
position2 = calcSignalPosition(input, 14)
puts(position2)

