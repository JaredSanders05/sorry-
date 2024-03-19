# Todo List!

Try to complete the list top to bottom and to label which parts are being worked on currently.


# List

- Piece Class
	> Color
	> Draw function (Takes in coordinates)
- Box Class
	>Record of the piece on the space 
	>Coordinates (X, Y, Z);
	>Type of box (Special - moves 3 places ahead putting all pieces in its way to their start) 
	>Color (White is default any other color is a slide pieces are not allowed to slide on its own color slide but can still move 					 	 	like its white)
- Dices Class
	> Roll Function (Rolls dice and return top int 1-6)
- Start Class (Each named the color)
	>Starts with 4 pieces and has a location on the board 
	>ArrayList< Piece >
	>int[] of X and Y cords for the draw function for the pieces in its circle
	>Draw function 
	>Add piece function for when a piece dies
	>Spawn Piece function
- Home Class (Each named the color)
	>ArrayList< Piece >
	>int[] of X and Y cords for the draw function for the pieces in its circle
	>Draw function 
- Game Script
	>ArrayList< Boxes >
	>SetUp function 
	- Puts 4 pieces in each Start Class with its color
	- Randomly picks color that start
	>Turn Function
	- Rolls dice
	- Can leave start if 1 or 2
	- If not in start just move ___ spaces
	> Move Function
	- Moves pieces from one box draws then move to next till its moved ___ times
	



