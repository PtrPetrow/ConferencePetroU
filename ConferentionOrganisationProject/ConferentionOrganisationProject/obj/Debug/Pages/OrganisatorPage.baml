   M S B A M L   `   `   `  ����Z  VConferentionOrganisationProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:ConferentionOrganisationProject.Pages%ConferentionOrganisationProject.Pages  5      ;    5ConferentionOrganisationProject.Pages.OrganisatorPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:ConferentionOrganisationProject.Pages     5        N� Title$  OrganisatorPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      6   �� 5      $��40 �6   6*   .+�5   
   �� $'��!Окно Организатора��6   $��Center=�6-   $��Center=�6J   $
��Bold"�6e   $��20(�6w   6�   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $	��220 �6#   61   �� 5      6%    5      �� 5      $
��2.5* �6    60   �� 5      6"   .+�5      �� $��0��6   $��0��6)   $��Center=�66   $��Center=�6Q   $��10q�5       .+�5!      �� 
���   �$��1q�6-    �� CornerRadius$ 8��6A   ._�5"      �� ��5#      �� 5$       �� Path$ 
User_Photo�6&    �� TargetNullValue 5%   "   �� 5&   &    �� 	UriSource$ /Resource/Placeholder.png?�62   5(      5*      5+      5,      �� 5.      $	��Top=�6   $��1��6-   $��0��6:   $	��150��6J   $��50��6V   $��Мой профиль��6b   $��14(�6x   6�   �� 50      $��1��6   $��2��6)   $��Center=�6:   $	��Top=�6W   .+�51      �� -   5         ��Name$ 	HelloText��51      $��10q�6/   $��Center=�6;   $
��Bold"�52      $��20(�6.   6>   �� 53      $
��Bold"�6   $��20(�6.   $��Center=�6<   $��0 0 0 60q�6Y   �� 54      -   5         ��Name$ 
GenderText��54   "   $� ��6   68    �� 55      �6   �� *	User_Name+67   56      �� 57      -   5        	 ��Name$	 EventsButton��57   /   $��Мероприятия��6   $	��100��58      $	��400��6&   
 � 	Resources
 59       �� 
TargetType �� Property �� Value��%c   '��       �� 5:      " ��6    .�5;      ��  �@��CornerRadius$ 6��6=   6I   5<      5=      5>      �� 5?      -   5        $	 ParticipantsButton��5?   -   $��Участники��6   $	��100��5@      $	��400��6&   $��6q�62   
 5A      ��%c   '��       �� 5B      " ��6    .�5C      ��  �@��CornerRadius$ 6��6=   6I   5D      5E      5F      �� 5G      -   5        $	 JuriesButton��5G   (   $��Жюри��6   $	��100��5H      $	��400��6&   
 5I      ��%c   '��       �� 5J      " ��6    .�5K      ��  �@��CornerRadius$ 6��6=   6I   5L      5M      5N      5O      5Q      �� 5S   
   -   5        $	 
BackButton��5S   M      RegistrationButton#��[  6   $��
Назад��6=   $
��Left=�5T   .   $��Bottom=�5U      $��2��6,   $��	10 0 0 10q�69   6N   �� 5W   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Center=�6J   $��2��6e   .+�5X      �� -   5        $	 RegJuryModButton��5X   s   #��[  6   $	��200��6A   $:��4Регистрация жюри/модератора��6M   $��Right=�5Y   4   $��	10 0 10 0q�6P   6e   5Z      5[      5\      