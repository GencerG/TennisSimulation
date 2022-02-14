# TennisSimulation
A simple program that simulates tennis tournaments between players.
## Build Requirements
This application is developed in `Windows` environment with `.NET` version `4.7.2` You may need to upgrade your .NET version or downgrade the project version before start building.
## Usage 
+ Just provide json input file under `app/src/Resources` directory with file name `input.json`.
  + Example:  
  ```yaml
    "players": [
    {
      "id": 1,
      "hand": "right",
      "experience": 10,
      "skills": {
        "clay": 2,
        "grass": 8,
        "hard": 3
      }   
    },
    {
      "id": 2,
      "hand": "right",
      "experience": 30,
      "skills": {
        "clay": 3,
        "grass": 5,
        "hard": 8
      }    
    }
   ],
   "tournaments": [
    {
      "id": 1,
      "surface": "clay",
      "type": "elimination"
    },
    {
      "id": 2,
      "surface": "clay",
      "type": "league"
    }
  ````
  ## Outputs
  + Program will create output json file in `app/src/Resources` with file name `output.json`. Players will be sorted in descending order by their total experiences.
    + Example:
      ```yaml
      [
        {
          "order": 1,
          "id": 16,
          "gained_experience": 942,
          "total_experience": 1020
        },
        {
          "order": 2,
          "id": 15,
          "gained_experience": 799,
          "total_experience": 890
        },
        {
          "order": 3,
          "id": 14,
          "gained_experience": 836,
          "total_experience": 870
        },
          {
          "order": 4,
          "id": 10,
          "gained_experience": 760,
          "total_experience": 814
        }
      ]
      ```
      + Also Console Logs:  
      ![image](https://cdn.discordapp.com/attachments/640134171456569376/942684266129657956/console2.jpg)  
      ![image](https://cdn.discordapp.com/attachments/640134171456569376/942684265936736316/console1.jpg)
