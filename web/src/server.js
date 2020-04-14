const express = require('express')
const app = express()
const port = 4000
const bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({ extended: true }));

const bruno = 
    { 
        email: 'bruno',
        password: 'abddjdjdkj'
    }

let users = [ 
    bruno
];

let adminUsers = [ 
    bruno
];

app.get('/api/users', (req, res) => {
    const response = {
        users,
        page: 1,
        hasPreviousPage: false,
        hasNextPage: false
    }
    return res.json(response)
})

app.post('/api/users', (req, res) => {
    const user = req.body
    users = users.concat(user) // add (not mutative)
    console.log(">>", user)

    console.log("user")
    return res.json({ status: "ok" })
})

app.listen(port, () => console.log(`Example app listening at http://localhost:${port}`))