import { useState } from 'react'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Login from './pages/Login.jsx'
import PrivateRoute from './components/PrivateRoute.jsx'
import AuthProvider from './components/AuthProvider.jsx'
import AuthLayout from './layouts/AuthLayout.jsx'
import MainLayout from './layouts/MainLayout.jsx'
import Dashboard from './pages/Dashboard.jsx'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
      <AuthProvider>
          <Router>
              <Routes >
                  {/* Login sayfasý farklý bir layout kullanýyor */}
                  <Route path="/login" element={
                      <AuthLayout>
                          <Login />
                      </AuthLayout>
                  } >
                      
                  </Route>

                  {/* Ana sayfa farklý bir layout ile sarýlý */}
                  <Route path="/home" element={
                      <PrivateRoute>
                          <MainLayout>
                              <Dashboard />
                            </MainLayout>
                      </PrivateRoute>
                  } >
                     
                  </Route>

                  {/* Dashboard, özel bir layout ile sarýlý ve PrivateRoute ile korunuyor */}
                  {/*<PrivateRoute path="/dashboard">*/}
                  {/*    <DashboardLayout>*/}
                  {/*        <DashboardPage />*/}
                  {/*    </DashboardLayout>*/}
                  {/*</PrivateRoute>*/}

                  {/* Varsayýlan rota */}
                  <Route path="/" element={
                      <AuthLayout>
                          <Login />
                      </AuthLayout>
                  } >
                     
                  </Route>
              </Routes>
          </Router>
      </AuthProvider>
  )
}

export default App
