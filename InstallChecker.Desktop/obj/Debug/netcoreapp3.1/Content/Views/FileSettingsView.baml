   M S B A M L   `   `   `  ����Q  MInstallChecker.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:InstallChecker.Desktop.ViewsInstallChecker.Desktop.Views  5      3    -InstallChecker.Desktop.Views.FileSettingsView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:InstallChecker.Desktop.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Z VPrism.Unity.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5
       � 	Resources 5         DarkModeButton �� 
TargetType " MaterialDesignFlatDarkBgButton �� BasedOn �� Property   MaterialDesignDarkBackground �� Value��%�   &	        7  7  �� 5   
   " ��6'   8   .�5      ��  � ��8  6+   �� 5       � ��$ 0q�60   �� 5       � ��
 �����6+   5      5      .��5      ��  5   
   ��%�  '��       '�� �     '�� K    �� 5      " ��6   .�5      ��  � ��$	 0,5q�6+   �� 5       � ��$	 420��6-   �� 5       � ��
 �����6/   �� 5       � ��$ 14(�6-   5      �� 5      " ��6   .�5      ��  � ��
 �����6/   �� 5       � ��
 ���� 6/   �� 5        � ��$ 0q�64   5!      �� 5"      " ��6   .�5#      ��  � ��$	 0,5q�6+   5$      5%      .+�5'   
   �� $
��Name��6   �� 5(   
   ��6   �� *ApplicationName+�� 5)   
   $
��Path��6   �� 5+   
    �� Orientation$ 
Horizontal=�6   .+�5,      �� $	��390��5-      ��5.      �� *ApplicationPath+�� 5/      $��30��50      $��20��51      $	��...��52      #��[  53      ��54      �� *BrowseCommand+55      �� 57   
   #��[  58      $
��Save��59      $
��0 10q�5:      ��57      �� *SaveApplicationCommand+5:      5;      5<      