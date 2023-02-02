/*
In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.

Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographically in this alien language.
https://leetcode.com/problems/verifying-an-alien-dictionary/

*/
using System;

public class Solution {
    public static bool IsAlienSorted(string[] words, string order) {
        int[] orderMap = new int[26];
        for (int i = 0; i < order.Length; i++) {
            orderMap[order[i] - 'a'] = i;
        }
        
        for (int i = 1; i < words.Length; i++) {
            string word1 = words[i - 1];
            string word2 = words[i];
            int j = 0;
            while (j < Math.Min(word1.Length, word2.Length)) {
                if (word1[j] != word2[j]) {
                    if (orderMap[word1[j] - 'a'] > orderMap[word2[j] - 'a']) {
                        return false;
                    }
                    break;
                }
                j++;
            }
            if (j == Math.Min(word1.Length, word2.Length) && word1.Length > word2.Length) {
                return false;
            }
        }
        

        return true;
    }

    static void Main(string[] args){
        string[] words = {"hello","leetcode"};
        string order = "hlabcdefgijkmnopqrstuvwxyz";
        
        Console.WriteLine(IsAlienSorted(words, order));

    }


}
