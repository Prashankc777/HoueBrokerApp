# HouseBroker MVP

## Database Configuration

Before running the application, update the connection string:

- File: `HouseBrokerMVP.API/appsettings.json`
- Key: `ConnectionStrings:DefaultConnection`
- Set it according to your SQL Server setup (hostname, database name, authentication).

---

## Automatic Database Initialization

When you run the project, it automatically applies the latest Entity Framework migration to the database.  
No need to manually run `add-migration` or `update-database`.

> ✅ Just run the project — if the database doesn't exist, it will be created.

---

## Swagger UI Enabled

The API is fully documented with Swagger.

> 🧪 Swagger will launch automatically when the project starts (in development mode).  
> You can test all endpoints from there without any external tool.

Swagger URL:  
`https://localhost:{port}/swagger` (replace `{port}` with your actual app port)

---

## API Endpoints

### Authentication – `api/auth`

#### 🔐 Login  
**POST** `/login`  
Authenticate a user using their email and password.

- **Request Body:**
  - `emailAddress`
  - `password`

#### 🧑‍💼 Register Broker  
**POST** `/register-broker`  
Create a new broker account.

- **Request Body:**
  - `emailAddress`, `password`, `confirmPassword`, `phoneNumber`

#### 🔄 Change Password  
**POST** `/change-password`  
Authenticated users can change their password.

#### 👤 Get My Details  
**GET** `/me`  
Get profile info of the logged-in user.

---

### Property Type – `api/property-type`

- `GET /` – List property types  
- `GET /{id}` – Get property type by ID  
- `POST /` – Add new property type  
- `PUT /{id}` – Update property type  
- `DELETE /{id}` – Delete property type

> 🔐 All endpoints require authentication

---

### Property – `api/property`

#### 🔎 Search Properties  
**GET** `/search`  
Optional query params: `location`, `minPrice`, `maxPrice`, `propertyType`

#### 📋 Get All  
**GET** `/`  
Returns all properties (requires auth)

#### 📄 Get by ID  
**GET** `/{id}`  
Returns property details (requires auth)

#### ➕ Add Property  
**POST** `/`  
Submit new property (multipart form)

- Fields: `Name`, `price`, `propertyTypeId`, `address`, `description`, `Images[]`

#### 🖊 Update Property  
**PUT** `/{id}`  
Update existing property (form-data)

#### ❌ Delete Property  
**DELETE** `/{id}`  
Remove a property by ID

---

## Notes

- JWT Authentication and role-based access control are implemented.
- Image uploads are stored in the `PropertyImage` folder and served via `/propertyImage` endpoint.
- Swagger UI is auto-enabled on startup to test all endpoints easily.

---

