using SWAD_Assignment2_Team3;

Console.Write("1. Admin\n2. User");
int option = Convert.ToInt32(Console.ReadLine());
string userType;
if (option == 1)
{
    userType = "Admin";
}
else
{
    userType = "User";
}