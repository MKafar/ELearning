import React, { Component } from 'react';
import { Header, Button } from 'semantic-ui-react';

import './StudentCoding.scss';
import CodeMirror from '../../components/CodeMirror/CodeMirror';
import Output from '../../components/CodeMirror/Output';


class StudentCoding extends Component {

    state = {
        exercises: [
            { number: 1, title: 'Jakiś tytuł ćwiczenia' },
        ],

    }

    render() {

        const sendCodeHandler = () => {
            console.log('wysłano');
        }
        
        const showexercise = () => {
            console.log('Treść zadania');
        }

        return (
            <div className='codingStudent'>
                <Header size='large'>Imię i nazwisko Tytuł zadania <Button className="exercisedeatilsbutton" onClick={showexercise}>Treść zadania</Button></Header>
                
                <div className='codingContainer'>
                    <div>
                        <CodeMirror></CodeMirror>
                    </div>
                        <div>
                            <Output></Output>
                            <Button className='sendbutton' onClick={sendCodeHandler}>Wyślij</Button>
                        </div>
                </div>
            </div>
        );
    }
}

export default StudentCoding;