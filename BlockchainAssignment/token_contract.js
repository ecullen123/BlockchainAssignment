// token_contract.js

// metadata
storage.name        = "DemoToken";
storage.symbol      = "DMT";
storage.decimals    = 18;

// total supply and per-address balances
storage.totalSupply = 1000000;
storage.balances    = {};      // mapping address → uint
storage.allowances  = {};      // mapping owner → (spender → uint)

storage.initialized = false;

// Initialize: mint entire supply to the deployer
function initialize(owner) {
  if (!storage.initialized) {
    storage.balances[owner] = storage.totalSupply;
    storage.initialized = true;
  }
  return storage.totalSupply;
}

// Read your balance
function balanceOf(addr) {
  return storage.balances[addr] || 0;
}

// Transfer tokens: args = [to, amount, sender]
function transfer(to, amount, sender) {
  if ((storage.balances[sender] || 0) < amount) {
    throw "Insufficient balance";
  }
  storage.balances[sender] -= amount;
  storage.balances[to] = (storage.balances[to] || 0) + amount;
  return true;
}

// Approve another address to spend on your behalf
// args = [spender, amount, owner]
function approve(spender, amount, owner) {
  storage.allowances[owner] = storage.allowances[owner] || {};
  storage.allowances[owner][spender] = amount;
  return true;
}

// Check allowance
function allowance(owner, spender) {
  return (storage.allowances[owner] || {})[spender] || 0;
}

// Transfer from one account using allowance
// args = [from, to, amount, spender]
function transferFrom(from, to, amount, spender) {
  var allowed = (storage.allowances[from] || {})[spender] || 0;
  if (allowed < amount) throw "Allowance exceeded";
  if ((storage.balances[from] || 0) < amount) throw "Insufficient balance";
  storage.allowances[from][spender] -= amount;
  storage.balances[from]     -= amount;
  storage.balances[to]       = (storage.balances[to] || 0) + amount;
  return true;
}
