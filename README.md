# final_master_thesis
# Configuration
		
		++1++
		
***OpenSlideViewer***

CONFIG.py -> SLIDE_DIR = r'C:\Users\AnnaToshiba2\Desktop\WSI\Sharpness_WebApp_Uploads'

*** Path to directory for WSI uploads
*** must be changed

		
*******WebApp********

ControlPanelController.cs

		++2++

[Http]Index ->  var root = @"C:\Users\AnnaToshiba2\Desktop\WSI\Sharpness_WebApp_Uploads\";

*** Path to the directory for WSI uploads
*** must be changed

		++3++

[Http]Index ->	sharpnessConsoleApp.StartInfo.FileName = @"C:\Users\AnnaToshiba2\Documents\GitHub\sharpness\
				sharpness console App\SharpnessExplorationCurrent\SharpnessExplorationCurrent\bin\x64\Release
				\SharpnessExplorationCurrent.exe";
			
*** Path to the executable sharpness console app
*** must be changed
 