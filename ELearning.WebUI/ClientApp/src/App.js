import React, { Component } from 'react';
import 'semantic-ui-css/semantic.min.css';
import 'semantic-ui-react';
import {BrowserRouter} from 'react-router-dom';

import './App.css';
import Admin from './containers/Admin/Admin';

import Student from './containers/Student/Student';
import Login from './containers/Login/Login';

class App extends Component {


  state = {
  
  }


  render() {

    return (
      <BrowserRouter>
        <div className="App">
          {/* <div className='loginContener'>
            <Login />
          </div> */}

          <Admin />
        </div>
      </BrowserRouter>











        /* 
        //różne mody jednego komponentu
            <CodeWindow code={code}></CodeWindow>
            <CodeWindow changeMode={true} code={'Hello'}></CodeWindow>
        // tabela szukania
           { this.state.searches.map((search) => {
           return <SearchTable
           date = { search.date }
           lab = { search.lab }
           exercise = { search.exercise }
           student = { search.student } />
           })}
        
        
        //lista zadań
        <div className = 'detailList'>
            {this.state.exercises.map((exercise) => {
              return <DetailList
                number = { exercise.number }
                title = { exercise.title }
                date = { exercise.date }/>
            } )}
          </div> */


        /*
      <div className = "menu">
      <Menu></Menu>
      </div>
        <div className="logincontainer">
          <LoginInput></LoginInput>
          <LoginButton></LoginButton>
        </div>
        

         <div className='coding'>
          <Codemirror></Codemirror>
          <Output></Output>
        </div>
        */

      
    );
  }
}

export default App;