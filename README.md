# HouseBroker MVP

## Database Configuration

Before running the application, make sure to update the database connection string.

- File: `HouseBrokerMVP.API/appsettings.json`
- Update: `ConnectionStrings:DefaultConnection`
- Set it according to your SQL Server instance and authentication details.

---

## Automatic Database Initialization

This project includes an initial Entity Framework migration that is automatically applied when the application starts.

> ✅ No need to manually run `add-migration` or `update-database`.  
> As long as the connection string is correct, the database schema is applied automatically at runtime.

---

## API Endpoints

### Authentication

Base route: `api/auth`

#### 🔐 Login  
**POST** `/login`  
Authenticate a user with their credentials.

- **Body:**
  - `emailAddress`: User's email
  - `password`: User's password  
- **Response:**  
  `200 OK` – Authenticated | `400 Bad Request` – Invalid credentials

#### 🧑‍💼 Register Broker  
**POST** `/register-broker`  
Register a new broker account.

- **Body:**
  - `emailAddress`
  - `password`
  - `confirmPassword`
  - `phoneNumber`  
- **Response:**  
  `200 OK` – Registered | `400 Bad Request` – Validation errors

#### 🔄 Change Password  
**POST** `/change-password`  
Update current user's password.  
Requires authentication header.

- **Body:**
  - `oldPassword`
  - `newPassword`  
- **Response:**  
  `200 OK` – Success | `400 Bad Request` – Failure

#### 👤 Get Profile  
**GET** `/me`  
Retrieve authenticated user’s profile.  
Requires auth header.

---

### Property Types

Base route: `api/property-type`

- `GET /` – List all property types  
- `GET /{id}` – Get property type by ID  
- `POST /` – Add new property type  
- `PUT /{id}` – Update existing property type  
- `DELETE /{id}` – Remove a property type

> 🔐 All endpoints require authentication

---

### Property Listings

Base route: `api/property`

#### 🔎 Search Properties  
**GET** `/search`  
Query params (optional): `location`, `minPrice`, `maxPrice`, `propertyType`

#### 📋 Get All Properties  
**GET** `/` – List all properties (requires auth)

#### 📄 Get Property by ID  
**GET** `/{id}` – View single property details (requires auth)

#### ➕ Add Property  
**POST** `/` – Submit property details (multipart form)

- Fields:
  - `Name`, `price`, `propertyTypeId`, `address`, `description`
  - `Images` (file upload)

#### 🖊 Update Property  
**PUT** `/{id}` – Update property info (form-data)

#### ❌ Delete Property  
**DELETE** `/{id}` – Remove property entry

> 🔐 All property management endpoints require authentication

---

## Notes

- Role-based access and JWT authentication are implemented.
- Image uploads are stored in the `PropertyImage` folder and served statically via `/propertyImage`.

---

Let me know if you want to add example requests/responses or Swagger UI info to impress further.
