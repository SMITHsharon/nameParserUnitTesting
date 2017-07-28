using System;

namespace NameParser
{
    public class Parser
    {
        private string[] namePieces;
        private int index = 0;

        public User ParseName(string name)
        {
            var user = new User();

            namePieces = name.Split(' ');

            var prefix = false;
            if (nameHasPrefix(namePieces[0]))
            {
                user.Prefix = namePieces[index];
                prefix = true;
                index++;
            }
            
            // assume all names have First Name
            user.FirstName = namePieces[index];
            index++;

            // Middle Initial / Last Name / Suffix
            if (namePieces.Length > 1) 
            {
                if (nameHasMiddleInit(namePieces[index]))
                {
                    user.MiddleInitial = namePieces[index];
                    user.LastName = namePieces[index+1];
                    index += 2;
                }
                else
                {
                    user.LastName = namePieces[index];
                    if (nameHasSuffix(namePieces.Length, prefix))
                    {
                        index++;
                        user.Suffix = namePieces[index];
                    }
                }
            }
        return user;
        }

    
        public bool nameHasPrefix (string thisName)
        {
            char lastChar = thisName[thisName.Length - 1];
            return ((thisName.Length>2) && lastChar == '.') ? true : false;
        }


        public bool nameHasMiddleInit (string thisName)
        {
            return ((thisName.Length == 1) || thisName[1] == '.') ? true : false;
        }


        public bool nameHasSuffix (int arrayLength, bool prefix)
        {
            return ((arrayLength > 2 && !prefix)) ? true : false;
        }
    }
}