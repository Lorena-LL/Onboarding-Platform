import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import SignInPage from "./pages/SignInPage";
import { isLoggedIn } from "./utils/session";

function App() {
    const authenticated = isLoggedIn();
    
    return (
        <BrowserRouter>
            <Routes>
                <Route 
                    path="/"
                    element={!authenticated ? <SignInPage /> : <Navigate to="/home" replace />}
                />
                <Route
                    path="/home"
                    element={authenticated ? <div> Home Page </div> : <Navigate to="/" replace />}
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;