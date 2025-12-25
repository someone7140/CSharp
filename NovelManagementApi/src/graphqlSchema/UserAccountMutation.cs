namespace NovelManagementApi.src.graphqlSchema;

using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.service;


[ExtendObjectType("Mutation")]
public class UserAccountMutation
{
    public UserAccountResponse AddUserAccountByGoogleAuth(
        string registerToken,
        string userSettingId,
        string name,
        [Service] IUserAccountService userAccountService)
    {
        return userAccountService.AddUserAccount(registerToken, userSettingId, name);
    }

}
