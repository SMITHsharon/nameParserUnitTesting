using System;

namespace NameParser
{
    public class Parser
    {
        public User ParseName(string name)
        {
            var user = new User();

            var namePieces = name.Split(' ');
            var index = 0;

            // check for Prefix
            var prefix = false;
            char last = namePieces[0][namePieces[0].Length - 1];
            if ((namePieces[0].Length>2) && last == '.')
            {
                user.Prefix = namePieces[index];
                prefix = true;
                index++;
            }
            
            // First Name
            user.FirstName = namePieces[index];
            index++;

            // Middle Initial / Last Name / Suffix
            if (namePieces.Length > 1) 
            {
                if (namePieces[index].Length == 1 || namePieces[index][1] == '.')
                {
                    user.MiddleInitial = namePieces[index];
                    user.LastName = namePieces[index+1];
                    index += 2;
                }
                else
                {
                    user.LastName = namePieces[index];
                    index++;
                    if (namePieces.Length > 2 && !prefix) 
                    {
                        user.Suffix = namePieces[index];
                    }
                }
            }

            return user;
        }
        
    }
}