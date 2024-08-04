![屏幕截图 2024-08-04 184732](https://github.com/user-attachments/assets/2a20e3c7-4a7e-4557-bf6c-6f485b97cd79)
eye.pt --- 100 training sets from MPIIGaze dataset.
Appearance-based Gaze Estimation in the Wild, X. Zhang, Y. Sugano, M. Fritz and A. Bulling, Proc. of the IEEE Conference on Computer Vision and Pattern Recognition (CVPR), June, p.4511-4520, (2015). 
![image](https://github.com/user-attachments/assets/d0f3a09d-2374-4a79-8fc9-699691e0075c)
######################################################################################################################################
This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License. To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/4.0/ or send a letter to Creative Commons, PO Box 1866, Mountain View, CA 94042, USA.
######################################################################################################################################

Here you can find the contents for the MPIIGaze dataset.

Data: The main samples in original and normalized format.

Evaluation Subset:
We used a evaluation subset of MPIIGaze for the experiments in our paper, where we randomly select 3000 samples (1500 left eyes and 1500 righ eyes) for each participants. The txt files include the image file name and "left" or "right" eye we used in the image.

Annotation Subset:
We also annotated 10,848 images with 12 facial landmarks, face bounding box, two eye bounding boxes, and pupil position.


--------------------------------------------------------------------------------------------------------------------------------------------


environment:
opencv-python             4.1.2.30  
python                    3.8.15

