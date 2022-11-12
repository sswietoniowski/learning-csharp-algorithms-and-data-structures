﻿namespace neetcode.P0210_CourseScheduleII;

// https://leetcode.com/problems/course-schedule-ii/
// https://youtu.be/Akt3glAwyfY
public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (var edge in prerequisites)
        {
            graph[edge[0]].Add(edge[1]);
        }

        var visited = new HashSet<int>();

        var result = new List<int>();

        bool dfs(int course)
        {
            if (visited.Contains(course))
            {
                return false;
            }

            if (graph[course].Count == 0)
            {
                return true;
            }

            visited.Add(course);

            foreach (var nextCourse in graph[course])
            {
                if (!dfs(nextCourse))
                {
                    return false;
                }
            }

            visited.Remove(course);
            graph[course].Clear();

            result.Add(course);
            return true;
        }

        for (int i = 0; i < numCourses; i++)
        {
            if (!dfs(i))
            {
                return new int[0];
            }
        }

        return result.ToArray();
    }
}