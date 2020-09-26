# Is success (positive selection) luck or hard work?

This piece of code just validates the idea shared by [Veritasium](https://www.youtube.com/channel/UCHnyfMqiRRG1u-2MsSQLbXA) - [Is Success Luck or Hard Work?](https://www.youtube.com/channel/UCHnyfMqiRRG1u-2MsSQLbXA) , that the success of candidates can be attributed to luck in larger candidate pools.

# Summary
Success of candidates can be attributed to luck in larger candidate (> 1000 times) pools, but success of candidates in smaller pools (< 100 times) can be heavily attributed to their skills.

This aligns with the theory that it is hard to shine in highly populous countries for highly skilled individuals.

# Assumption
Skills weigh in for 95% of candidate score and other factors such as luck contribute to 5% of candidate.

# Method
1. Generate random levels of skills and luck scores for X number of candidate.
2. Find the total scores (summing 95% of skills score and 5% of the luck) for each of them.
3. Find the top 1 candidate out of these pool of candidates.
4. Get the candidate skill and luck.
5. Repeat for X from 1 to 10000.

# Extra step for visualization
6. Average over 10 data points for smoothing out spikes.

# Results
## Up to 100 times the candidates
![](https://github.com/amul047/skills-or-luck/blob/master/SkillAndLuckByCandidatePoolSize_100.png)
## Up to 1000 times the candidates
![](https://github.com/amul047/skills-or-luck/blob/master/SkillAndLuckByCandidatePoolSize_1000.png)
## Up to 10000 times the candidates
![](https://github.com/amul047/skills-or-luck/blob/master/SkillAndLuckByCandidatePoolSize_10000.png)

