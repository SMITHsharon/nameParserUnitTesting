using System;

namespace NameParser
{
    public class Parser
    {
        public User ParseName(string name)
        {
            var user = new User();

            var namePieces = name.Split(' ');

            user.FirstName = namePieces[0];
            if (namePieces.Length > 1)
            {
                if (namePieces[1].Length == 1 || namePieces[1][1] == '.')
                {
                    user.MiddleInitial = namePieces[1];
                }
                else
                {
                    user.LastName = namePieces[1];
                }
            }

            return user;
        }
        
    }
}