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
                  {/* Login sayfas� farkl� bir layout kullan�yor */}
                  <Route path="/login" element={
                      <AuthLayout>
                          <Login />
                      </AuthLayout>
                  } >
                      
                  </Route>

                  {/* Ana sayfa farkl� bir layout ile sar�l� */}
                  <Route element={<PrivateRoute />}>
                      <Route path="/dashboard" element={<MainLayout>
                          <Dashboard />
                      </MainLayout>} />
                      {/* �sterseniz ba�ka korumal� rotalar ekleyebilirsiniz */}
                  </Route>
                  <Route element={<PrivateRoute />}>
                      <Route path="/competitions" element={<MainLayout>
                          <Competitions />
                      </MainLayout>} />
                      {/* �sterseniz ba�ka korumal� rotalar ekleyebilirsiniz */}
                  </Route>
                  <Route element={<PrivateRoute />}>
                      <Route path="/leagues" element={<MainLayout>
                          <Leagues />
                      </MainLayout>} />
                      {/* �sterseniz ba�ka korumal� rotalar ekleyebilirsiniz */}
                  </Route>
                  <Route element={<PrivateRoute />}>
                      <Route path="/myteam" element={<MainLayout>
                          <MyTeam />
                      </MainLayout>} />
                      {/* �sterseniz ba�ka korumal� rotalar ekleyebilirsiniz */}
                  </Route>
                  <Route element={<PrivateRoute />}>
                      <Route path="/contributor" element={<MainLayout>
                          <Contributor />
                      </MainLayout>} />
                      {/* �sterseniz ba�ka korumal� rotalar ekleyebilirsiniz */}
                  </Route>
                  
                     

                  {/* Dashboard, �zel bir layout ile sar�l� ve PrivateRoute ile korunuyor */}
                  {/*<PrivateRoute path="/dashboard">*/}
                  {/*    <DashboardLayout>*/}
                  {/*        <DashboardPage />*/}
                  {/*    </DashboardLayout>*/}
                  {/*</PrivateRoute>*/}

                  {/* Varsay�lan rota */}
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
