//   Project : Battlecruiser3.0
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/16/2018


using Homebrew;

public static class Tag
{
    #region GROUPS 0 - 10

    [TagField(categoryName = "groups")] public const int GroupPlayer = 0;
    [TagField(categoryName = "groups")] public const int GroupEnemy = 1;
    [TagField(categoryName = "groups")] public const int GroupCreature = 2;

    #endregion

    #region STATES 11-100

    [TagField(categoryName = "states")] public const int StateKiiled = 11;
    [TagField(categoryName = "states")] public const int StateLookUp = 12;
    [TagField(categoryName = "states")] public const int StateAttacking = 13;
    [TagField(categoryName = "states")] public const int StateAppearing = 14;

    #endregion
}