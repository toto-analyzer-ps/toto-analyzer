
#  Toto Analyzer (.NET  Console App)

##  Description
This project is a console application developed in .NET  that performs statistical analysis on lottery (TOTO 6x49) data.  
It loads draw results, analyzes number frequency, identifies hot pairs, calculates distribution, and visualizes results directly in the console.

---

##  Features
- Load lottery draw data from online JSON source
- Fallback dataset if API is unavailable
- Top N most frequent numbers
- Hot pairs analysis
- Number distribution by ranges
- Console-based heat map visualization

---

## Technologies
- .NET 
- C#
- LINQ
- HttpClient
- System.Text.Json

---

##  Project Structure
- Program.cs → Main menu and user interaction
- DataLoader.cs → Loads data from API / fallback
- Statistics.cs → Data analysis logic
- Visualizer.cs → Console visualization
- Draw.cs → Data model

---

##  How to Run
1. Open project in Visual Studio
2. Build solution
3. Run Program.cs

---

##  Author
Student Project 
