   M S B A M L   `   `   `  ���� \  XInstall_WVA_Connect_CDI_All_Users, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Install_WVA_Connect_CDI_All_Users!Install_WVA_Connect_CDI_All_Users  2    ,Install_WVA_Connect_CDI_All_Users.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Alocal/clr-namespace:Install_WVA_Connect_CDI_All_Users     $	��450��$	��500��  � WindowStyle$
  None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������� � 	Resources    LoginButtonGroup �� EndPoint �� 
StartPoint � Color � Offset  ExamsButtonGroup �� 
TargetType	 �� Property
 �� Value �� 
TargetType �Name ��Name �� CornerRadius 
� GradientOrigin �� RelativeTransform �� CenterX �� CenterY �� ScaleX �� ScaleY T� X T� Y �� Triggers P� Property P� Value �� 
TargetName  ImageButtonStyle��%O  &	        &	 R     '�� �     7  &	 �    �� $ 0.5,1&�$ 0.5,0&�.��� $ Black��$ 0Q�� $ White��$ 1Q��� $	 0,0&�$	 1,1&�.��� $ LightSlateGray��$
 0.02Q�� $ 
WhiteSmoke��$
 0.22Q�� $ LightSlateGray��$	 .53Q��� " ��.��� 	 � ��8
   �� 	 � ��$
 Center=��� 	 � ��

 ������� 	 � ��$
 
Sitka Text)��� 	 � ��$
 Center=��� 	 � ��$
 1q��� 	 � ��
 �� " ��.R�� $
 grid��.+��� $ border��$ 3,3,3,3��
���   �$��1.6,1.9,2.9,2.9q���
� $ 0.496,1.052&� V� .~��� $	 0.5Q�$	 0.5Q�$	 1.5Q�$	 1.5Q�T� $
 0.02Q�$	 0.3Q�.��� $ 1Q�$ 	#FF327EC3��� $	 0.3Q�$ 	#FF327EC3��._��� $��Center=�$��Center=�$��Regular"� P�  �@J�IsMouseOver . . ��� 	 � ��

 �   ��� $ border��	 � ��
 
� $ 0.496,1.052&� V� .~��� $	 0.5Q�$	 0.5Q�$ 2Q�$ 2Q�T� $
 0.02Q�$	 0.9Q�.��� $ 	#FF327EC3��$ 1Q�� $ White��$	 0.3Q�P�  � �� . . ��� 	 � ��

 �   ��� $ border��	 � ��
 
� $ 0.496,1.052&� V� .~��� $	 0.5Q�$	 0.5Q�$ 2Q�$ 2Q�T� $
 0.02Q�$	 0.9Q�.��� $ White��$ 1Q�� $ 	#FF327EC3��$	 0.3Q�P�  � {� .  . ��� $
 grid��	 �@J�Opacity$

 0.25Q��� " ��.��� 	 � ��
 �� " ��.R��� .��� ���� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF327EC3��$ 1Q�� $ White��$ 0.246Q�� $ 	#FF98BEE1��$ 0.724Q�.+��� $��	60,0,60,0q�$��Center=�.+��� -   $��RequirementsLabel��$��0,0,0,10q�$L��FRequirements: Have WVA_Connect_CDI installed and click 'Begin Install'��$��
Sitka Text)�$
��Wrap=�$��18(� �� TextAlignment$ Center=�$��Center=��� 
���   �$��Stretch=�$��2���� -   $��UserInstallLabel��$��	0,10,0,10q�$P��JCheck users profiles below that will have the 'WVA_Connect_CDI' installed.��$��
Sitka Text)�$
��Wrap=�$��18(�$ Center=�$
��Left=���  �� Orientation$ 
Horizontal=�$��Center=�$��0,0,0,10q�.+��� -    ��Name$ SelectAllButton��$��
Select All��$��Center=�$��0,0,10,0q�$	��100��$��16(�$��24��$��3�� K� ZIndex$ 1���� -   $ DeselectAll��$��Deselect All��$��Center=�$��0,0,0,0q�$	��100��$��16(�$��24��$��3��$ 1��&   System.Windows.Controls.DataGrid  -   $��AvailableUsersTable��   HeadersVisibility$
 None=�$	��210��
������     AutoGenerateColumns  .  !   CanUserResizeRows! .  "   CanUserAddRows" .  $��DemiBold"�$��1q�#   
IsReadOnly# .  $��
Sitka Text)�$��16(�$	��156������ *AvailableUser+$   Columns$ 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn%   Width5  /System.Windows.Controls.DataGridLengthConverter$% * &   Header$& MF��'   MinWidth$' 60Q�1  +System.Windows.Controls.DataGridBoundColumn(   Binding( �� ) �� Path$) UserName�4  .System.Windows.Controls.DataGridTemplateColumn  $% 35 $& 
Accessible��*   
IsReadOnly* .  +   CellTemplate+ �� .R��� $��Center=�$��Center=�$��Center=�, d� 	IsChecked, �� $) 	IsChecked�- �� UpdateSourceTrigger$- PropertyChanged=��� -   $ InstallButton��$��Begin Install��$��Center=�$��0,10,0,0q�$	��160��$��22(�$��35��$��3��$ 1���� -   $��CloseButton��$��Close��$��Center=�$��0,10,0,0q�$	��160��$��22(�$��35��$��3��$ 1��