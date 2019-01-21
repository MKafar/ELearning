import React, { Component } from 'react';
import { Container, Dropdown, Header, List, Button, Divider } from 'semantic-ui-react';
import axios from '../../axios';

import './Grade.scss';

const options = [
    { key: 1, text: '0', value: 0 },
    { key: 2, text: '1', value: 1 },
    { key: 3, text: '2', value: 2 },
    { key: 4, text: '3', value: 3 },
    { key: 5, text: '4', value: 4 },
    { key: 6, text: '5', value: 5 },
    { key: 7, text: '6', value: 6 },
    { key: 8, text: '7', value: 7 },
    { key: 9, text: '8', value: 8 },
    { key: 10, text: '9', value: 9 },
    { key: 11, text: '10', value: 10 }
]

class Grade extends Component {

    state = {
        case1 : 0, 
        case2 : 0, 
        case3 : 0,
        case4 : 0,
        avgScore : 0
    }

    handleChange = (e, { name, value }) => {
        this.setState({ [name]: value})  
    }
    avgScoreHandler = () => {
        this.setState({avgScore : Math.floor(this.state.case1 + this.state.case2 + this.state.case3 + this.state.case4)/4})
    }

    sendScoreHandler = () => {
        console.log(this.props);
        axios.post('/api/Evaluations/Create', {
             assignmentid: this.props.assignment,
             sectionid: this.props.section,
              grade: this.state.avgScore
        }).then(response => {
             console.log(response);
        }).catch(error=>{
             console.log(error.response);
        })
    }

    render() {

        return (
            <div className="gradeselectcontainer">
                <Container>
                    <Header as='h3' dividing>Oceń studenta</Header>
                    <div>
                        <List divided verticalAlign='middle'>
                            <List.Item>
                                <List.Content floated='right'>
                                    <Dropdown 
                                    value = {this.state.case1}
                                    name='case1'
                                    placeholder='0'
                                    direction='right' 
                                    compact 
                                    selection 
                                    options={options}
                                    onChange={(this.handleChange)}
                                    ></Dropdown>
                                </List.Content>
                                <List.Content>
                                    Zgodność z treścią zadania
                            </List.Content>
                            </List.Item>

                            <List.Item>
                                <List.Content floated='right'>
                                    <Dropdown
                                    value = {this.state.case2}
                                    name='case2' 
                                    placeholder='0' 
                                    direction='right' 
                                    compact 
                                    selection 
                                    options={options}
                                    onChange={(this.handleChange)}
                                    ></Dropdown>
                                </List.Content>
                                <List.Content>
                                    Czytelność
                            </List.Content>
                            </List.Item>

                            <List.Item>
                                <List.Content floated='right'>
                                    <Dropdown
                                    value = {this.state.case3}
                                    name='case3' 
                                    placeholder='0' 
                                    direction='right' 
                                    compact 
                                    selection 
                                    options={options}
                                    onChange={(this.handleChange)}
                                    ></Dropdown>
                                </List.Content>
                                <List.Content >
                                    Odporność na błędy
                            </List.Content>
                            </List.Item>

                            <List.Item>
                                <List.Content floated='right'>
                                    <Dropdown
                                    value = {this.state.case4}
                                    name='case4' 
                                    placeholder='0' 
                                    direction='right' 
                                    compact 
                                    selection 
                                    options={options}
                                    onChange={(this.handleChange)}
                                    ></Dropdown>
                                </List.Content>
                                <List.Content >
                                    Optymalizacja
                            </List.Content>
                            </List.Item>
                        </List>
                    </div>

                    <Divider />

                    <List>
                        <List.Item>
                            <List.Content floated='right'>
                                <Button onClick={this.sendScoreHandler} >Wyślij</Button>
                                <Button onClick={this.avgScoreHandler} >Oblicz</Button>
                            </List.Content>
                            <List.Content>
                                <Header as='h4'>Średnia ocena: {this.state.avgScore} </Header>
                            </List.Content>
                        </List.Item>
                    </List>
                </Container>
            </div>

        )
    }
}

export default Grade