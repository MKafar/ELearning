import React, { Component } from 'react';
import 'semantic-ui-css/semantic.min.css';
import 'semantic-ui-react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import './App.css';
import Admin from './containers/Admin/Admin';
import Student from './containers/Student/Student';
import Login from './containers/Login/Login';

class App extends Component {
  
  state = {
    user: {
      roles: []
    }
  }

  render() {
    return (
      <BrowserRouter>
        <div className="App">
          <Switch>
            <Route path='/student' component={Student} />
            <Route path='/admin' component={Admin} />
            <Route exact path='/' component={Login} />
          </Switch>
        </div>
      </BrowserRouter>
    );
  }
}

export default App;