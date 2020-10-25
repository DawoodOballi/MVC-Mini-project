# ASP.NET MVC Application



#### Class Diagram for WPF-EF project

![](/oldprojectcd.png)



#### Class Diagram for ASP.NET MVC Application

![image-20201025175508740](/classdiagram.png)







## Observations



* The architecture of the MVC application is much more sophisticated and detailed in contrast to the WPF-EF application. 
* The Aesthetics of the MVC application are of better quality.
* The WPF-EF architecture consisted of 3 layers where one layer is dependent on only another layer.
* The MVC application architecture layout illustrated interlinked dependencies where the Controllers were dependent on the front end as well as the backend.
* The architecture of the MVC application allows for more flexibility when adding more models and controllers to the application whilst maintaining separation of concerns.
* The WPF-EF app operated based on a business layer which contained all of the CRUD operations. The ASP.NET MVC app operates on the controllers being the caretakers of what operation to carry out based on the views which were created for them.
* Each model in the MVC had its own controller with its own operations, although some controller may have the same operations. The WPF-EF app had CRUD operations which were used for all the different views.