import { useState } from 'react'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Login from './pages/Login.jsx'
import PrivateRoute from './components/PrivateRoute.jsx'
import AuthProvider from './components/AuthProvider.jsx'
import AuthLayout from './layouts/AuthLayout.jsx'
import MainLayout from './layouts/MainLayout.jsx'
import Dashboard from './pages/Dashboard.jsx'
import Competitions from './pages/Competitions.jsx'
import Leagues from './pages/Leagues.jsx'
import MyTeam from './pages/MyTeam.jsx'
import Contributor from './pages/Contributor.jsx'
import './App.css'

function App() {

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
                  <Route element={<PrivateRoute />}>
                      <Route path="/dashboard" element={<MainLayout>
                          <Dashboard />
                      </MainLayout>} />
                      {/* Ýsterseniz baþka korumalý rotalar ekleyebilirsiniz */}
                  </Route>
                  <Route element={<PrivateRoute />}>
                      <Route path="/competitions" element={<MainLayout>
                          <Competitions />
                      </MainLayout>} />
                      {/* Ýsterseniz baþka korumalý rotalar ekleyebilirsiniz */}
                  </Route>
                  <Route element={<PrivateRoute />}>
                      <Route path="/leagues" element={<MainLayout>
                          <Leagues />
                      </MainLayout>} />
                      {/* Ýsterseniz baþka korumalý rotalar ekleyebilirsiniz */}
                  </Route>
                  <Route element={<PrivateRoute />}>
                      <Route path="/myteam" element={<MainLayout>
                          <MyTeam />
                      </MainLayout>} />
                      {/* Ýsterseniz baþka korumalý rotalar ekleyebilirsiniz */}
                  </Route>
                  <Route element={<PrivateRoute />}>
                      <Route path="/contributor" element={<MainLayout>
                          <Contributor />
                      </MainLayout>} />
                      {/* Ýsterseniz baþka korumalý rotalar ekleyebilirsiniz */}
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
