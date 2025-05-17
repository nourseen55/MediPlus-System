<h1 align="center"><img src="https://medi-plus.runasp.net/img/logo.png"></h1>
<h2 align="center">Mediplus Hospital Management System</h2>

<img src="https://github.com/user-attachments/assets/f9e7c889-3474-4a40-845a-879d5af0348a"/>
<p>
    Mesiplus is a <strong>Hospital Management System (HMS)</strong> that automates the hospital’s operations, helping manage 
    patient appointments, medical records, departments, and staff efficiently. It streamlines the workflow 
    from patient registration to discharge.
</p>

</br>
<h3>Roles & Users</h3>
<ul>
    <li>🛠️ <strong>Admin</strong></li>
    <li>👨‍⚕️ <strong>Doctor</strong></li>
    <li>👩‍⚕️ <strong>Nurse</strong></li>
    <li>👤 <strong>Patient</strong></li>
</ul>

</br>
<h2>🚀 Application Features</h2>
<ul>
    <li><strong>🛠️ Admin</strong></li>
    <ul>
        <li>Has access to a comprehensive dashboard with full control over the system and its users.</li>
        <li>Can enable, disable, and manage system users.</li>
        <li>Perform CRUD operations for <strong>Doctors</strong> and <strong>Nurses</strong>.</li>
        <li>View recent activities in the system, including <strong>News</strong>, <strong>Feedback</strong>, and other user actions.</li>
        <li>Edit and update their own profile information.</li>
    </ul>
    <li><strong>👨‍⚕️ Doctor</strong></li>
    <ul>
        <li>Add and manage their available working hours.</li>
        <li>View and manage their patients, including adding medical records for each patient.</li>
        <li>Post news and updates for patients to see, including special offers.</li>
        <li>Add educational qualifications to their profile for patients to review.</li>
        <li>Doctors can only log in to the system (registration is managed by the admin).</li>
        <li>Edit and update their own profile information.</li>
    </ul>
    <li><strong>👩‍⚕️ Nurse</strong></li>
    <ul>
        <li>View and manage scheduled appointments.</li>
        <li>Access doctors' patients' information to assist in patient care.</li>
        <li>Nurses can only log in to the system (registration is managed by the admin).</li>
        <li>Edit and update their own profile information.</li>
    </ul>
    <li><strong>🧑‍💼 Patient</strong></li>
    <ul>
        <li>Book and manage appointments with doctors, including payments and cancellations.</li>
        <li>Provide feedback, send emails, and contact doctors or system support.</li>
        <li>Can register and log in to the system.</li>
        <li>Edit and update their own profile information.</li>
    </ul>
</ul>

</br>
<h2>🔒 Application Security</h2>
<ul>
    <li>🔐 Secure registration, login, and profile updates with full attribute validation, implemented using ASP.NET Identity.</li>
    <li>🔑 Strong password enforcement for all users.</li>
    <li>🛡️ Protection against CSRF, XSS, and DDoS attacks for enhanced security.</li>
    <li>🌐 Third-party login and registration support using Google OAuth for convenience and security.</li>
</ul>

</br>
<h2>🛠️ Technologies Used to Build this Application</h2>
<table align="center">
        <tr>
            <td><img src="https://img.icons8.com/color/48/000000/c-sharp-logo.png" alt="C#" width="40" height="40"/><br>C#</td>
            <td><img src="https://img.icons8.com/color/48/000000/database.png" alt="Database" width="40" height="40"/><br>Database</td>
            <td><img src="https://img.icons8.com/color/48/000000/microsoft-sql-server.png" alt="MS SQL Server" width="40" height="40"/><br>MS SQL Server</td>
            <td><img src="https://i.ytimg.com/vi/wwEa5kIfzos/maxresdefault.jpg" alt="LINQ" width="40" height="40"/><br>LINQ</td>
            <td><img src="https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/ef8.png" alt="EF Core" width="40"/><br>Entity Framework Core</td>
        </tr>
        <tr>
            <td><img src="https://img.icons8.com/color/48/000000/html-5.png" alt="HTML5" width="40" height="40"/><br>HTML5</td>
            <td><img src="https://img.icons8.com/color/48/000000/css3.png" alt="CSS3" width="40" height="40"/><br>CSS3</td>
            <td><img src="https://img.icons8.com/color/48/000000/javascript.png" alt="JavaScript" width="40" height="40"/><br>JavaScript</td>
            <td><img src="https://img.icons8.com/color/48/000000/bootstrap.png" alt="Bootstrap" width="40" height="40"/><br>Bootstrap</td>
            <td><img src="https://img.icons8.com/ios-filled/50/000000/jquery.png" alt="jQuery" width="40" height="40"/><br>jQuery</td>
        </tr>
        <tr>
            <td><img src="https://img.icons8.com/?size=100&id=1BC75jFEBED6&format=png&color=000000" alt="ASP.NET Core" width="40" height="40"/><br>ASP.NET MVC Core</td>
            <td><img src="https://th.bing.com/th/id/OIP.2mTC_bV6esSP2eUS3LV2BQAAAA?rs=1&pid=ImgDetMain" alt="Razor Pages" width="60"/><br>Razor Pages</td>
            <td><img src="https://th.bing.com/th/id/R.1cff3475adf7ae0b3ac228190d21a0ef?rik=aA0jkFYYtZbl7Q&pid=ImgRaw&r=0" alt="Fluent API" width="60"/><br>Fluent API</td>
            <td><img src="https://tech.playgokids.com/static/5080497fdeb321559343c59f795a5dcf/f3583/automapper-logo.png" alt="AutoMapper" width="40"/><br>AutoMapper</td>
        </tr>
</table>

<br/>
<h2>🌟 Architecture & Design</h2>

### What is Clean Architecture?

Clean Architecture is a software design philosophy that emphasizes the separation of concerns, making your codebase easier to manage, test, and scale. It allows developers to create systems that are flexible and adaptable to change, promoting high cohesion and low coupling between components.

### Why Use Clean Architecture?

- **Improved testability:** Each component can be tested independently.
- **Maintainability:** Changes in one part of the system have minimal impact on others.
- **Scalability:** New features can be added with less effort.
- **Separation of concerns:** Different aspects of the application can be developed and maintained separately.
<div align="center">
<img src="https://github.com/user-attachments/assets/eb2d7828-9237-420b-9912-eaeef9d84ee9" width="75%" />
</div>

<br/>
<h2>🕸️ Hosting & Production</h2> 
I'm proud to host my website using **MonsterAsp.net**, complemented by its robust cloud database services.  
🌐 Feel free to click <a href="https://medi-plus.runasp.net">here</a> to explore the live project!<br/>
You can try login with this users
 
- **✅ Doctor**
   - Email: `lila@gmail.com`
   - Password: `Lila@123`

- **✅ Nurse**
   - Email: `Liam1@gmail.com`
   - Password: `Liam@123`

- **✅ Patient**
   - Go and create your account from <a href="https://medi-plus.runasp.net/Identity/Account/Register">here</a><br/>
    OR
   - Try to login if you already have an account from <a href="https://medi-plus.runasp.net/Identity/Account/Login">here</a>
- **❌ Admin**
   - Can't login as an Admin

## 🚀 Getting Started

Follow these instructions to set up and run the project on your local machine.

### Prerequisites

Ensure you have the following software installed on your system:

- [.NET SDK](https://dotnet.microsoft.com/download) (at least version 8.0)
- [Git](https://git-scm.com/)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Clone the Repository

To get a copy of the project up and running locally, first clone the repository using Git:
```bash
git clone https://github.com/nourseen55/MediPlus-System.git
cd MediPlus-System
```
### Build and Run the project
1. Open the project in Visual Studio or Visual Studio Code.
2. Restore the necessary packages:
    ```bash
    dotnet restore
    ```
3. Build the project:
    ```bash
    dotnet build
    ```
4. Run the project:
    ```bash
    dotnet run
    ```


<br/>
<h2>🤝 Contributors & Developers</h2>
<div>
    <ol>
        <li><a href="https://github.com/7usseinel8areb" target="_blank"><strong>Hussein Elghareb</strong></a></li>
        <li><a href="https://github.com/nourseen55" target="_blank"><strong>Nourseen Mohsen</strong></a></li>
        <li><a href="https://github.com/Rahma-Akmal" target="_blank"><strong>Rahma Akmal</strong></a></li>
        <li><a href="https://github.com/amaalselim" target="_blank"><strong>Amaal Selim</strong></a></li>
        <li><a href="https://github.com/rahma-mohmed" target="_blank"><strong>Rahma Mohmed</strong></a></li>
    </ol>
</div>

<br/>
<h3>📞 Contact Information</h3>
For any inquiries or support, please contact me at: <a href="mailto:hospitalmanagments@gmail.com">hospitalmanagments@gmail.com</a>

<br/>
<h3>📜 License Information</h3>
© Copyright 2024 | All Rights Reserved by <a href="mailto:hospitalmanagments@gmail.com">hospitalmanagments@gmail.com</a>
