import React, { Component } from 'react';
import CodeMirror from 'react-codemirror';

import './CodeWindow.scss';
import 'codemirror/lib/codemirror.css';
import 'codemirror/mode/clike/clike';
import 'codemirror/theme/neat.css';
import 'codemirror/addon/edit/closebrackets.js';


class CodeWindow extends Component {
    state = {
        name: 'CodeMirror',
        code: null,
        changeMode: false

    };

    render() {
        let options = null;
        if (this.props.changeMode) {
            options = {
                lineNumbers: true,
                mode: 'text/x-c++src',
                theme: 'neat',
                autoCloseBrackets: true,
                readOnly: true

            };
        } else {
            options = {
                lineNumbers: true,
                mode: 'text/x-c++src',
                theme: 'neat',
                autoCloseBrackets: true,
            };
        }



        return (
            <div>
                <CodeMirror  value={this.props.code} options={options} />
            </div>
        );
    }
}

export default CodeWindow;
