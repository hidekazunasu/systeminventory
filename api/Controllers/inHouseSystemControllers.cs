using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using systeminventory_sample.Models.DbFirst;

namespace inHouseSysmte.Controllers;

// APIコントローラーを示す属性
[ApiController]
// ルートURLの指定
[Route("[Controller]")]

public class inHouseSysmteController : ControllerBase
{
    // データベースコンテキストの設定
    private readonly inHouseDbContext _context;

    public inHouseSysmteController(inHouseDbContext context)
    {
        _context = context;
    }

    // GETリクエストに対するアクションメソッドの指定
    [HttpGet]
    [Route("api/inHouseSystem")]

    public async Task<ActionResult<IEnumerable<inHouseSystem>>> Get()
    {
        // データの取得
        var data = await _context.Systems.ToListAsync();
        // 取得したデータを返す
        return data;
    }

    // GETリクエストに対するアクションメソッドの指定
    [HttpGet("{id}")]
    public async Task<ActionResult<inHouseSystem>> GetSystem(string id)
    {
        // 指定されたIDのシステムを取得
        var system = await _context.Systems.FindAsync(id);
        // システムが存在しない場合は404を返す
        if (system == null)
        {
            return NotFound();
        }
        // 取得したシステムを返す
        return system;

    }

    // PUTリクエストに対するアクションメソッドの指定
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSystem(string id, inHouseSystem system)
    {
        // IDの不一致をチェック
        if (id != system.Id)
        {
            return BadRequest();
        }
        // データの状態を変更
        _context.Entry(system).State = EntityState.Modified;

        try
        {
            // 変更をデータベースに保存
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            // データの更新に失敗した場合は、IDが一致しない場合はBadRequestを返す
            if (id != system.Id)
            {
                return BadRequest();
            }
            else
            {
                // それ以外の場合は例外をスロー
                throw;
            }
        }
        // 更新が成功した場合は204を返す
        return NoContent();
    }

    // POSTリクエストに対するアクションメソッドの指定
    [HttpPost]
    public async Task<ActionResult<inHouseSystem>> PostSystem(inHouseSystem system)
    {
        // システムをデータベースに追加
        _context.Systems.Add(system);
        // 変更をデータベースに保存
        await _context.SaveChangesAsync();
        // 追加したシステムを返す
        return CreatedAtAction(nameof(Get), new { id = system.Id }, system);
    }
}
