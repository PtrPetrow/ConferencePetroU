   M S B A M L   `   `   `  ����Z  VConferentionOrganisationProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:ConferentionOrganisationProject.Pages%ConferentionOrganisationProject.Pages  5      9    3ConferentionOrganisationProject.Pages.ListViewFrame   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:ConferentionOrganisationProject.Pages     5        N� Title$)  #Список мероприятий��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      6   �� 5      $��50 �6   6*   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   .+�5      �� -   5         ��Name$ DirectionComboBox��5      $	��160��62   $��30��5      $
��Left=�6   $��Center=�5      $��Center=�6.   $��	10 0 20 0q�5       �� DisplayMemberPath$ Directions_Name��6&   5   O   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ DatePickerElement��5      $
��Left=�64      SelectedDateFormat$ Short=�5      $��Center=�64   $��30��5      $	��160��6%   6o   5      �� 5   
   -   5         ��Name$ EventsListView��5       $��1��6   $��Center=�68   ��5      �� 5      .R�5      � $��Center=�6    � ColumnDefinitions 5       �� 5!      61   �� 5"      $	��350 �6/   6=   .+�5$      �� $��10 0 0 0q�6    $��0��62   $��Center=�6B   $��Center=�6]   $	��150��6z   $	��150��6�   ��5%      �� 5&   "   	 �� Path$	 Event_Image�6*   
 �� TargetNullValue
 5'   &   �� 5(   *    �� 	UriSource$ /Resource/Placeholder.png?�66   6^   5*   #   5,      �� 5-      $ Vertical=�6%   $��2��6<   $��Center=�6L   $��Center=�6g   .+�5.      �� $
��Left=�6$   $��Center=�6?   $
��Bold"�6v   $
��Wrap=�6�    �� TextAlignment$
 Left=�5/   $   ��5.   Z   �� *
Event_Name+5/   ;   �� 50      $
��Left=�6(   $��Center=�6C   $
��Wrap=�6^   �� 51   "   $�Направление: ��6&   6=    �� 52   "   �6&   �� *Directions.Directions_Name+6T   53      �� 54      $
��Left=�6$   �� 55      $�Начало: ��6"   64    �� 56      �6"   �� *
Event_Date+ �� StringFormat$ 
dd.MM.yyyy��6Y   57      58      59      5:      5<      �� 5>   
   -   5         ��Name$ 
AuthButton��5>      $��2��6   $��Right=�5?      $��Center=�6-   $��Авторизация��5@      $
��10 0q�6'   $��30��65   $	��120��5A      68   5C      5D      