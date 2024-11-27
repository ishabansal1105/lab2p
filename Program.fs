/// Define the Coach record
type Coach = {
    Name: string
    FormerPlayer: bool
    Experience: int  // Added experience field
}

// Define the Stats record
type Stats = {
    Wins: int
    Losses: int
}

// Define the Team record
type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

// Create sample data for coaches with experience and record info
let coach1 = { Name = "Quin Snyder"; FormerPlayer = true; Experience = 10 }
let coach2 = { Name = "Joe Mazzulla"; FormerPlayer = false; Experience = 2 }
let coach3 = { Name = "Jordi Fernandez"; FormerPlayer = false; Experience = 0 }
let coach4 = { Name = "Charles Lee"; FormerPlayer = false; Experience = 0 }
let coach5 = { Name = "Billy Donovan"; FormerPlayer = true; Experience = 9 }

// Create sample data for team stats (Wins and Losses)
// Modified Wins to be less than Losses for each team
let stats1 = { Wins = 7; Losses = 12 }  // Atlanta Hawks
let stats2 = { Wins = 3; Losses = 15 }  // Boston Celtics
let stats3 = { Wins = 4; Losses = 12 }  // Brooklyn Nets
let stats4 = { Wins = 3; Losses = 13 }  // Charlotte Hornets
let stats5 = { Wins = 5; Losses = 12 }  // Chicago Bulls

// Create sample data for teams with respective coaches and stats
let team1 = { Name = "Atlanta Hawks"; Coach = coach1; Stats = stats1 }
let team2 = { Name = "Boston Celtics"; Coach = coach2; Stats = stats2 }
let team3 = { Name = "Brooklyn Nets"; Coach = coach3; Stats = stats3 }
let team4 = { Name = "Charlotte Hornets"; Coach = coach4; Stats = stats4 }
let team5 = { Name = "Chicago Bulls"; Coach = coach5; Stats = stats5 }

// Add teams to a list
let teams = [ team1; team2; team3; team4; team5 ]

// Filter successful teams (Wins < Losses)
let unsuccessfulTeams = teams |> List.filter (fun team -> team.Stats.Wins < team.Stats.Losses)

// Calculate success percentage for each team
let calculateSuccessPercentage team =
    let totalGames = float (team.Stats.Wins + team.Stats.Losses)
    let successRate = (float team.Stats.Wins / totalGames) * 100.0
    successRate

// Map the success percentage for all teams
let teamSuccessPercentages = teams |> List.map (fun team -> 
    (team.Name, team.Stats.Wins, team.Stats.Losses, calculateSuccessPercentage team)
)

// Print the success percentages and wins/losses for all teams
printfn "Success percentages for all teams (Wins - Losses):"
teamSuccessPercentages |> List.iter (fun (name, wins, losses, percentage) -> 
    printfn "%s: Wins = %d, Losses = %d, Success Rate = %.2f%%" name wins losses percentage
)

/////////////////////////////////////////////////////////

// Discriminated Union for Cuisine (for restaurant type)
type Cuisine =
    | Korean
    | Turkish

// Discriminated Union for Movie Type (for movie options)
type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

// Discriminated Union for Activity (for the Valentine's Day options)
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float  // (kilometers, fuel cost per km)

// Define the function to calculate the budget for an activity
let calculateBudget (activity: Activity) =
    match activity with
    | BoardGame -> 0.0  // No cost for board game
    | Chill -> 0.0      // No cost for chilling out
    | Movie movieType -> 
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks | IMAXWithSnacks | DBOXWithSnacks -> 22.0  // Set the cost for IMAX with Snacks to 22 CAD
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0  // Korean restaurant costs 70 CAD per couple
        | Turkish -> 65.0 // Turkish restaurant costs 65 CAD per couple
    | LongDrive (km, fuelCostPerKm) -> float km * fuelCostPerKm // Calculate cost based on distance and fuel cost per km

// Testing the budget calculation
let activity1 = Movie Regular
let activity2 = Restaurant Korean
let activity3 = LongDrive (100, 0.15)  // 100 km with 0.15 CAD per km

// Print the budget for each activity
printfn "\nBudget for Movie Regular: %.2f CAD" (calculateBudget activity1)
printfn "Budget for Korean Restaurant: %.2f CAD" (calculateBudget activity2)
printfn "Budget for Long Drive: %.2f CAD" (calculateBudget activity3)

/////////////////////////////////////////////////////////

// You can add more test cases if you like for different activities
let activity4 = Movie IMAXWithSnacks
let activity5 = Restaurant Turkish
let activity6 = LongDrive (250, 0.18) // 250 km with 0.18 CAD per km

// Print the budget for these activities
printfn "\nBudget for IMAX with Snacks: %.2f CAD" (calculateBudget activity4)
printfn "Budget for Turkish Restaurant: %.2f CAD" (calculateBudget activity5)
printfn "Budget for Long Drive (250 km): %.2f CAD" (calculateBudget activity6)
