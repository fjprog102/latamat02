# Langton's Ant!

The purpose of this kata is to implement a program that allow us to represent a Langton's Ant behavior. Langton's ant is a two-dimensional universal Turing machine with a very simple set of rules but complex emergent behavior, read mode about it [here](https://en.wikipedia.org/wiki/Langton%27s_ant).

## Rules
The Langnton's Ant consists of a group of squares on a plane (grid) colored variously either black or white. We arbitrarily identify one square as the “ant”. The ant can travel in any of the four cardinal directions at each step it takes. The “ant” moves according to the rules below:

- At a white square, turn 90° right, flip the color of the square, move forward one unit
- At a black square, turn 90° left, flip the color of the square, move forward one unit

## Goals
- Given a grid black and/or white squares and an initial "ant" square, show grid status after N steps taken by the "ant"
- Bonus: For the first goal, display the status of the grid after each step that the "ant" takes

## Example
 ![](../../resources/langtons-ant-animated.gif)