import React, { Component } from 'react';
import 'semantic-ui-css/semantic.min.css';
import 'semantic-ui-react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';
import axios from './axios';

import './App.css';
import Admin from './containers/Admin/Admin';
import Student from './containers/Student/Student';
import Login from './containers/Login/Login';
import { hasRole } from './auth';

class App extends Component
{
  state = {
    user: {
      roles: [],
      userid: null,
      username: ""
    }
  }

  onSetUser = (userProp) =>
  {
    this.setState({ user: userProp });
  }

  onClearUser = () =>
  {
    axios.defaults.headers.common['Authorization'] = "";

    this.setState({
      user: {
        roles: [],
        userId: null,
        userName: ""
      }
    })
  }

  render()
  {
    const user = this.state.user;

    return (
      <BrowserRouter>
        <div className="App">
          <Switch>

            {hasRole(user, ['Student']) && <Route path='/student' component={() => <Student
              user={user}
              onClearUser={this.onClearUser}
            />}
            />}

            {hasRole(user, ['Administrator']) && <Route path='/admin' component={() => <Admin
              user={user}
              onClearUser={this.onClearUser}
            />}
            />}

            <Route exact path='/' component={() => <Login
              user={user}
              onSetUser={this.onSetUser}
              onClearRoles={this.onClearRoles}
            />}
            />

            <Redirect from="*" to="/" />
          </Switch>
        </div>
      </BrowserRouter>
    );
  }
}

export default App;