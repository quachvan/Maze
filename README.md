Download the ZIP file and extract the file or open it in desktop.
Run the solution on Visual Studio and build.

Download Postman if you have not done so already.
Click on the dropdown and select 'POST'.
Paste this url into the textbox: http://localhost:8080/api/SolveMaze/
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
Sorry for the inconvenience, but Postman can not style '\r\n' into line breaks, so you will have to manually copy and paste it somewhere else and do the line breaks yourself. 
