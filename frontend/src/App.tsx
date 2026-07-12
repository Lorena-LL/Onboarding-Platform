import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import SignInPage from "./pages/SignInPage/SignInPage";
import { useSyncExternalStore } from "react";
import { isLoggedIn , subscribe } from "./utils/session";
import PageLayout from "./components/PageLayout/PageLayout";
import { ROUTES } from "./constants/general";
import ProfilePage from "./pages/ProfilePage/ProfilePage";
import ActiveTasksPage from "./pages/ActiveTasksPage/ActiveTasksPage";
import CompletedTasksPage from "./pages/CompletedTasksPage/CompletedTasksPage";
import TaskDetailsPage from "./pages/TaskDetailsPage/TaskDetailsPage";

function App() {
    const authenticated = useSyncExternalStore(
        subscribe,
        isLoggedIn 
    );
    
    return (
        <BrowserRouter>
            <Routes>
                <Route 
                    path={ROUTES.main}
                    element={!authenticated 
                        ? <SignInPage /> 
                        : <Navigate to={ROUTES.profile} replace />}
                />
                <Route
                    path={ROUTES.profile}
                    element={authenticated 
                        ? <PageLayout><ProfilePage /></PageLayout> 
                        : <Navigate to={ROUTES.main} replace />}
                />
                <Route
                    path={ROUTES.activeTasks}
                    element={authenticated 
                        ? <PageLayout><ActiveTasksPage /></PageLayout>
                        : <Navigate to={ROUTES.main} replace />}
                />
                <Route
                    path={ROUTES.completedTasks}
                    element={authenticated 
                        ? <PageLayout><CompletedTasksPage /></PageLayout>
                        : <Navigate to={ROUTES.main} replace />}
                />
                <Route
                    path={ROUTES.taskDetails}
                    element={authenticated 
                        ? <PageLayout><TaskDetailsPage /></PageLayout>
                        : <Navigate to={ROUTES.main} replace />}
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;