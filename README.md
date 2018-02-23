Download Postman if you have not done so already.
Click on the dropdown and select 'POST'.
Paste this url into the textbox: http://localhost:50941/api/SolveMaze/
Go to the 'Body' tab.
Choose the 'raw' and 'JSON(application/json)' format.
In the textbox enter your maze string under the 'Map' property in the body. 

Example: { Map: 
             "##########
              #A...#...#
              #.#.##.#.#
              #.#.##.#.#
              #.#....#B#
              #.#.##.#.#
              #....#...#
              ##########"
         }
         
Click 'Send' and you should see the response in the body. 
Postman can not turn '\r\n' into line breaks, so you will have to manually copy and paste it somewhere else and do the line breaks yourself. 
