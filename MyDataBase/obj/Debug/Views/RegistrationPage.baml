   M S B A M L   `   `   `  ����  
MyDataBase'    !MyDataBase.Views.RegistrationPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  RegistrationPage��5      .��5
      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*    � ColumnDefinitions 5   
   �� 5      $��25 �6   6,   �� 5      6!   �� 5      $��25 �6   6,   .+�5   
   �� $��1��6   $��1��6   ��6/   �� *ChildPageModel.ThisUser.Login+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� ValidatesOnDataErrors . �� 5   
   $��2��6   $��1��6   ��6/   �� *" ChildPageModel.ThisUser.Password+$ PropertyChanged=�$ TwoWay=� . �� 5   
   $��3��6   $��1��6   ��6/   �� *ChildPageModel.ThisUser.FName+$ PropertyChanged=�$ TwoWay=� . �� 5   
   $��4��6   $��1��6   ��6/   �� *ChildPageModel.ThisUser.LName+$ PropertyChanged=�$ TwoWay=� . �� 5   
   $��5��6   $��1��6   $��Check in��6.   ��6B   �� *	CheckIn+�� 5   
   $��6��6   $��1��6   $��Go to login��6.   ��6E   �� *	GoToLogin+�� 5   
   $��0��6   $��1��6   $��12(�6-   ��6;   �� *ChildPageModel.Error+$ PropertyChanged=�5       5!      