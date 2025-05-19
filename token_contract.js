// token_contract.js

// metadata
storage.name = "LoyaltyPoint";
storage.symbol = "LP";
storage.decimals = 0;

// total supply & balances
storage.totalSupply = 100000;
storage.balances = {};      // address → uint
storage.allowances = {};      // owner → (spender → uint)
storage.initialized = false;

// mint entire supply to deployer
function initialize(owner) {
    if (!storage.initialized) {
        storage.balances[owner] = storage.totalSupply;
        storage.initialized = true;
    }
    return storage.totalSupply;
}

// check balance
function balanceOf(addr) {
    return storage.balances[addr] || 0;
}

// transfer points
function transfer(to, amount, sender) {
    if ((storage.balances[sender] || 0) < amount) throw "Insufficient balance";
    storage.balances[sender] -= amount;
    storage.balances[to] = (storage.balances[to] || 0) + amount;
    return true;
}

// approve another to spend on your behalf
function approve(spender, amount, owner) {
    storage.allowances[owner] = storage.allowances[owner] || {};
    storage.allowances[owner][spender] = amount;
    return true;
}

// check allowance
function allowance(owner, spender) {
    return (storage.allowances[owner] || {})[spender] || 0;
}

// transfer via allowance
function transferFrom(from, to, amount, spender) {
    var allowed = (storage.allowances[from] || {})[spender] || 0;
    if (allowed < amount) throw "Allowance exceeded";
    if ((storage.balances[from] || 0) < amount) throw "Insufficient balance";
    storage.allowances[from][spender] -= amount;
    storage.balances[from] -= amount;
    storage.balances[to] = (storage.balances[to] || 0) + amount;
    return true;
}