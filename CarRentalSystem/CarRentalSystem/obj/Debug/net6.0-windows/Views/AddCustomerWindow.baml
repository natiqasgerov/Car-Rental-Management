   M S B A M L   `   `   `  ????J  FCarRentalSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CarRentalSystemCarRentalSystem  5   	   '    !CarRentalSystem.AddCustomerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:CarRentalSystem  5   	   $	??550??5	   	   $	??900??6     ? AllowsTransparency$
  True??6"   
??????  ? WindowStyle$
 None=?5
   	    ? WindowStartupLocation$ Manual=?6    ? Left$	 308??6;   
 ? Top$	 150??6F   .??5      ?? -   5        ???	#FFF4F4F4._?5   
   ? .+?5      ?? -   5        $??45??5   *   $??30??65   ???	#FFE05F5F$??15(?6X   $??Right=?6f   $	??Top=?6?   $??	0,10,10,0q?6?   .??6?   X6?   ?? 5      $??Customer Details??6   $	??180??60   $??30??6<   $??20(?6H   $??Medium"?6V   $??Normal$?6j   $??74,10,646,510q?6}   6?   '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$ PersonMultipleAdd=?6&   ???	#FF5686D2$??40??6V   $??40??6b   $??24,3,0,0q?6m   6?   ?? 5      
???   ?$??1q?6)   $??1??6=   $
??auto??6H   $??
0,53,0,496q?6U   6k   ?? 5      -   5         ??Name$ nameCustomer_textbox??5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name??5      $	??170??67   $??15(?6C    %  !MaterialDesignFloatingHintTextBox#??[  5      $	??Top=?5      $??24,80,706,0q?6)   6>   ?? 5      -   5        $ phoneCustomer_textbox??5      $ Phone??5      $	??170??68   $??15(?6D   #??[  5      $	??Top=?5      $??254,80,427,0q?6)   6?   ?? 5      -   5        $ emailCustomer_textbox??5      $ Email??5      $??15(?68   #??[  5      $	??Top=?5      $??24,140,595,0q?6)   6?   ?? 5!      -   5        $ addressCustomer_textbox??5!      $ Address??5"      $??15(?6:   #??[  5#      $	??Top=?5$      $??24,210,536,0q?6)   6?   ?? 5&       ?? CornerRadius$ 80??6   ???	#FF5686D2$??1q?6@   $	??140??6T   $	??140??6`   $??704,80,56,330q?6m   ??5'      ?? 5(      -   5        imageCustomer_imagebrush??	 j? Stretch$
	 Fill=?5(   C   
 ?? ImageSource$
 \Images\user.jpg??6R   6s   5*      ?? 5,      -   5         ??Name$ browseCustomer_btn??5,       " MaterialDesignRaisedDarkButton#??[ 5-      ???	#FF5686D2$??Browse??5.   (   $??15(?69   $??704,239,114,279q?5/      6*   ?? 50      -	   5        $ deleteImageCustomer_btn??50      
???\\??$??793,239,54,279q?6M   .??51        $ Delete=?6*   $??18??68   $??18??6D   $??Center=?6O   6l   52      ?? 54        MaterialDesignGroupBox#??[ 55      $??24,275,263,10q?56      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Custom=?57         
Background ?	#FF5686D2   
Foreground
 ???????5:      ?? 5;       ?? Orientation$ 
Horizontal=?6!   $??27??6:   .+?5<        $ ShieldAccount=?62   $
??Left=?6G   $??25??6i   $??37??6u   ?? 5=      $??Other Information??6    $??14(?6<   $??Medium"?6J   
???????$??Right=?6q   5>      .??5@      ? .+?5B      (  "System.Windows.Controls.DatePicker  -
   5        $??birthDate_datepicker??5B   !   $	??140??5C      $??15(?6%   $ 
Birth Date??5D       $  MaterialDesignOutlinedDatePicker#??[ 5E      $??10,10,445,0q?6S   $	??Top=?6h     5G      -   5        $??issueDate_datepicker??5G   !   $	??140??5H      $??15(?6%   $
??Left=?63   $ 
Issue Date??5I      #??[ 5J      $??
210,10,0,0q?6S   $	??Top=?6g     5L      -   5        $??expiryDate_datapicker??5L   !   $	??140??5M      $??15(?6%   $ Expiry Date??5N      #??[ 5O      $??410,10,44,0q?6S   $	??Top=?6h   ?? 5Q      -   5        $ lisenceNo_textbox??5Q      $ 
Lisence No??5R      $	??120??6E   $??15(?6Q   #??[  5S      $	??Top=?5T      $??14,89,461,0q?61   ?? 5V      -   5        $??genderCustomer_combobox??5V      $	??100??6>   $??15(?6J   $ Gender??5W      $??162,104,333,0q?6A   $	??Top=?6X   .@?5X      ?? $
??Male??5Y      ?? 5Z      $??Female??5[      5\      5]      5^      ?? 5a      -   5        $ saveCustomer_btn??5a        MaterialDesignRaisedButton#??[ 5b      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   Value$ -1Q?5c         IsIndicatorVisible$
 True??5d         IsIndeterminate$
 True??5e      $	??140??5f      $??35??6   $
??Save??6)   $??18(?68   ???	#FF5686D2+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??5g      $
{?True??5h      $??704,500,36,10q?6"   ???	#FF5686D25i      5j      5k      5l      