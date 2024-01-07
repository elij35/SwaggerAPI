# COMP2001
This is the git repository for the profile API micro-service

## Endpoints
### Get All Activities
HTTP Method: Get  
Endpoint: /activities   
Parameters: None    

This endpoint shows all activities    

### Delete User
HTTP Method: Delete   
Endpoint: /api/admin/delete/{id}   
Parameters: Email, Password   
Route Example: /api/admin/delete/1   

On success, this endpoint removes the inputted userID, this endpoint only works if the user is an admin   

### Get public Profile
HTTP Method: Get   
Endpoint: /api/user/public/{id}
Parameters: User ID 
Route Example: /api/user/public/1   

This endpoint shows the public profile of inputted userID      

### Create New User
HTTP Method: Put     
Endpoint: /api/user/new    
Parameters: Username, Email, Password   

This endpoint creates a new user    

### Get Token
HTTP Method: Post     
Endpoint: /api/user/get-token    
Parameters: Email, Password   

This endpoint gives the user a security token    

### Get Self
HTTP Method: Post     
Endpoint: /api/user/get-self/  
Parameters: Key      

This endpoint returns the user's details as a json format    

### Update
HTTP Method: Put       
Endpoint: /api/user/update    
Parameters: Key, Email, Location, Birthday, AboutMe, ProfilePicture, Units, ActivityTimePreference, Height, Weight, MarketingLanguage    

This endpoint updates the user's details    
