# Todo List!

Try to complete the list top to bottom and to label which parts are being worked on currently.

# Rules
>**Dice Rolls**
- 1 - Move any piece forward one space or move a piece out of start
- 2 - Move any piece forward two spaces or move a piece out of start and ALLWAYS go again
- 3 - 6 Move any piece that many spaces forward 
>**Bumping**
- If you land on a piece and bump it back to start
> **Winning**
- First person to get all pieces to their home

# List

 - [x] Piece Class
	>Color
	> Index (Location on board)
	>Draw function (Takes in coordinates)

- [ ] Box Class
	>Record of the piece on the space 
	>Coordinates (X, Y, Z);
	>Type of box (Special - moves 3 places ahead putting all pieces in its way to their start) 
	>Color (White is default any other color is a slide pieces are not allowed to slide on its own color slide but can still move like its white)
- [ ] Dices Class
	> -  [ ] Roll Function (Rolls dice and return top int 1-6)
- [ ] Start Class (Each named the color)
	>Starts with 4 pieces and has a location on the board 
	>ArrayList< Piece >
	>int[] of X and Y cords for the draw function for the pieces in its circle
	>-  [ ] Draw function 
	>Add piece function for when a piece dies
	> -  [ ] Spawn Piece function
- [ ] Home Class (Each named the color)
	>ArrayList< Piece >
	>int[] of X and Y cords for the draw function for the pieces in its circle
	>Draw function 
- [ ] Game Script
	>ArrayList< Boxes >
	>List of all piece for each color so you can know where each piece is so you can move it
	> - [ ] SetUp function 
	- Puts 4 pieces in each Start Class with its color
	- Randomly picks color that start
	> - [ ] Turn Function
	- Rolls dice
	- Can leave start if 1 or 2
	- If not in start just move ___ spaces
	> - [ ]  Move Function
	- Moves pieces from one box draws then move to next till its moved ___ times checking to see if it  	
