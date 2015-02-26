;#DropDB World_TimeSpace_1014EasyTest

#Application World_TimeSpace_1014Win
#Application World_TimeSpace_1014Web

*Action Navigation(User)

*ProcessRecord
 Full Name = ''

#IfDef World_TimeSpace_1014Web
*Action Edit
#EndIf
 
*FillForm
 Full Name = Test User
 
*Action Cancel

#IfDef World_TimeSpace_1014Win
*HandleDialog
 Respond = Yes
#EndIf

*CheckFieldValues
 Full Name = ''
