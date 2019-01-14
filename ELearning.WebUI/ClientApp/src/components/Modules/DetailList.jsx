import React from 'react'
import { Container, List, Button } from 'semantic-ui-react'
import './DetailList.scss'

const DetailList = (props) => {
    return (
        <div className='detailList'>
            <Container>
                <List divided relaxed>
                    <List.Item>
                        <List.Content floated='right'>
                            {props.visibledetail ? <Button onClick={props.detailsClicked}> Szczegóły </Button> : null}
                            {props.visibledelete ? <Button onClick={props.removeClicked}> Usuń </Button> : null}
                            {props.studentgrade}
                        </List.Content>
                        <List.Content floated='right'>
                            {props.finalgrade}
                        </List.Content>
                        <List.Content floated='left'>
                            {props.date}
                        </List.Content>
                        <List.Content >
                            {props.text}
                            {props.sectionnumber}
                            {props.title}                        
                            {props.number}
                            {props.name}
                            &nbsp;&nbsp;&nbsp;
                            {props.studentname}
                            {props.studentgroup}
                            &nbsp;&nbsp;&nbsp;
                            {props.studentsection}
                        </List.Content>
                        <List.Content>
                            {props.abreviation}
                        </List.Content>
                        <List.Content floated='left' >
                            {props.variant}
                            {props.subject}
                        </List.Content>
                        <List.Content floated='left'>
                            {props.group}
                            {props.grade}
                        </List.Content>
                        <List.Content floated='left'>
                            {props.section}
                        </List.Content>
                    </List.Item>
                </List>
            </Container>
        </div>
    );
}
export default DetailList;