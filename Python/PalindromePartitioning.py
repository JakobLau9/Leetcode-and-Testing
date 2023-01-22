class Solution(object):
    def partition(self, s):
        """
        :type s: str
        :rtype: List[List[str]]
        """
        def backtrack(s, curr, res):
            if not s:
                res.append(curr)
                return

            for i in range(1, len(s) + 1):
                if is_palindrome(s[:i]):
                    backtrack(s[i:], curr + [s[:i]], res)

        def is_palindrome(s):
            return s == s[::-1]
            
        res = []
        backtrack(s, [], res)
        return res
