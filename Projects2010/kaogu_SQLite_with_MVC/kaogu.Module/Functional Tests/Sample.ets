;#DropDB kaogu_0730EasyTest

#Application kaogu_0730Win
#Application kaogu_0730Web

*Action Navigation(User)

*ProcessRecord
 Full Name = ''

#IfDef kaogu_0730Web
*Action Edit
#EndIf
 
*FillForm
 Full Name = Test User
 
*Action Cancel

#IfDef kaogu_0730Win
*HandleDialog
 Respond = Yes
#EndIf

*CheckFieldValues
 Full Name = ''
